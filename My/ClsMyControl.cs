using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; //新增

namespace My
{
    public class MyControl
    {
        #region 決定TreeView如何選取節點

        /// <summary>
        /// 決定TreeView如何選取節點
        /// </summary>
        /// <param name="node">資料型態為TreeNode</param>
        /// <param name="FindNodeType">要選擇節點的方式
        /// Previous　, PreviousVisible , Next , NextVisible , First , Last
        /// </param>
        public static void SelectNode(TreeNode node, string FindNodeType)
        {
            if (node.IsSelected)
            {
                // 決定TreeNode如何被選取.
                switch (FindNodeType)
                {
                    case "Previous":
                        node.TreeView.SelectedNode = node.PrevNode;
                        break;
                    case "PreviousVisible":
                        node.TreeView.SelectedNode = node.PrevVisibleNode;
                        break;
                    case "Next":
                        node.TreeView.SelectedNode = node.NextNode;
                        break;
                    case "NextVisible":
                        node.TreeView.SelectedNode = node.NextVisibleNode;
                        break;
                    case "First":
                        node.TreeView.SelectedNode = node.FirstNode;
                        break;
                    case "Last":
                        node.TreeView.SelectedNode = node.LastNode;
                        break;
                }
            }
            node.TreeView.Focus();
        }

        #endregion


        #region 遞回取出每一個node的資訊

        /// <summary>
        /// 遞回取出每一個node的資訊
        /// </summary>
        /// <param name="treeNode">傳入資料型態為TreeNode的變數</param>
        public static void PrintRecursive(TreeNode treeNode)
        {
            // 顯示treeNode資訊內容
            MessageBox.Show(treeNode.Text);

            // 遞回取出每一個node的資訊.
            foreach (TreeNode tn in treeNode.Nodes)
            {
                PrintRecursive(tn);
            }
        }

        #endregion


        #region 將TreeView傳入此程序來進行處理.

        /// <summary>
        ///  將TreeView傳入此程序來進行處理.
        /// </summary>
        /// <param name="treeView"></param>
        public static void CallRecursive(TreeView treeView)
        {
            // 取出TreeView的所有節點
            TreeNodeCollection nodes = treeView.Nodes;
            foreach (TreeNode n in nodes)
            {
                PrintRecursive(n);
            }
        }

        #endregion


        #region "ComboBox控制項填入數值"

        public static void ComboBoxGetNumber(ComboBox comobj, int num)
        {
            int i = 0;
            comobj.Items.Clear();
            for (i = 0; i < num - 1; i++)
            {

                comobj.Items.Add(i);
            }


        }

        #endregion


    }
}
