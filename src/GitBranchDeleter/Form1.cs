using NGit;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GitBranchDeleter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonBrowser_Click(object sender, EventArgs e)
        {
            var folderSelector = new FolderBrowserDialog();
            folderSelector.Description = "Select your GIT project root folder";
            if (folderSelector.ShowDialog() == DialogResult.OK && !string.IsNullOrEmpty(folderSelector.SelectedPath))
            {
                textBoxFolderPath.Text = folderSelector.SelectedPath;
            }
        }

        private async void buttonFetchBranches_Click(object sender, EventArgs e)
        {
            treeViewBranches.BeginUpdate();
            treeViewBranches.Nodes.Clear();
            await FetchBranchesAndFillTree();
            treeViewBranches.EndUpdate();

        }

        private async Task FetchBranchesAndFillTree()
        {
            var gitRepository = NGit.Api.Git.Open(textBoxFolderPath.Text).GetRepository();

            foreach (var branch in gitRepository.GetAllRefs())
            { 
                //Not really needed. I was doing something heavy here before that actually did await correctly....
                await Task.Yield();

                if (branch.Key.StartsWith("refs/remotes/"))
                    continue;

                var splitPath = branch.Key.Split('/');
                TreeNode previousNode = null;
                for (int level = 0; level < splitPath.Count(); level++)
                {
                    TreeNode newNode = null;
                    if (previousNode != null)
                    {
                        newNode = previousNode.Nodes.Find(splitPath[level], false).FirstOrDefault();
                        if (newNode == null)
                        {
                            newNode = previousNode.Nodes.Add(splitPath[level], splitPath[level]);
                        }
                    }
                    else
                    {
                        newNode = treeViewBranches.Nodes.Find(splitPath[level], true).FirstOrDefault();
                        if (newNode == null)
                        {
                            newNode = treeViewBranches.Nodes.Add(splitPath[level], splitPath[level]);
                        }
                    }

                    previousNode = newNode;
                }
            }

            gitRepository.Close();
        }

        private void treeViewBranches_AfterCheck(object sender, TreeViewEventArgs e)
        {
            //Passes down the check request to check all children. 
            if (e.Action != TreeViewAction.Unknown)
            {
                if (e.Node.Nodes.Count > 0)
                {
                    foreach (TreeNode node in e.Node.Nodes)
                    {
                        this.CheckAllChildNodes(e.Node, e.Node.Checked);
                    }
                }
            }

            //Passes UP the check request to say that the tick should no longer be there (Since it hasn't selected all children. 
            if(e.Node.Checked == false && e.Node.Parent != null)
            {
                e.Node.Parent.Checked = false;
            }
        }

        private void CheckAllChildNodes(TreeNode treeNode, bool nodeChecked)
        {
            foreach (TreeNode node in treeNode.Nodes)
            {
                node.Checked = nodeChecked;
                if (node.Nodes.Count > 0)
                {
                    this.CheckAllChildNodes(node, nodeChecked);
                }
            }
        }

        private async void buttonDelete_Click(object sender, EventArgs e)
        {
            foreach (var node in treeViewBranches.Nodes.Cast<TreeNode>())
            {
                var nodeList = GetTreeNodeDescendants(node, new List<TreeNode>());
                foreach (var branchNode in nodeList)
                {
                    if (branchNode.Checked)
                    {
                        var branchName = GetFullGitPathFromTreeNode(branchNode, string.Empty);
                        await Task.Yield();
                        NGit.Api.Git.Open(textBoxFolderPath.Text)
                            .BranchDelete()
                            .SetBranchNames(branchName)
                            .SetForce(true)
                            .Call();

                        UpdateStatus("Successfully deleted the branch " + branchName);
                    }
                }
            }
        }

        private string GetFullGitPathFromTreeNode(TreeNode node, string childPath)
        {
            if (node.Parent != null)
                return GetFullGitPathFromTreeNode(node.Parent, "/" + node.Text + childPath);
            else
                return node.Text + childPath;
        }

        private IEnumerable<TreeNode> GetTreeNodeDescendants(TreeNode node, List<TreeNode> currentList)
        {
            if (node.Nodes.Count == 0)
            {
                currentList.Add(node);
            }
            else
            {
                foreach(var childNode in node.Nodes.Cast<TreeNode>())
                {
                    GetTreeNodeDescendants(childNode, currentList);
                }
            }

            return currentList;
        }

        private void UpdateStatus(string status)
        {
            var scrollBox = false;
            if (listBoxUpdates.SelectedIndex == listBoxUpdates.Items.Count - 1)
                scrollBox = true;

            listBoxUpdates.Items.Add(status);

            if (scrollBox)
                listBoxUpdates.SelectedIndex = listBoxUpdates.Items.Count - 1;
        }
    }
}
