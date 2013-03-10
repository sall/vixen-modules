using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Vixen.Data.Flow;
using Vixen.Module;
using Vixen.Module.OutputFilter;
using Vixen.Services;
using Vixen.Sys;
using Vixen.Sys.Output;
namespace VixenModules.Preview.VixenPreview.Shapes
{
    class PreviewTools
    {

        static double Perimeter(PreviewPoint p1, PreviewPoint p2) 
        {
            double p;
            double a;
            double b;
            a = Math.Abs(p2.Y - p1.Y);
            b = Math.Abs(p2.X - p1.X);
            p = Math.PI * ((3 * (a + b)) - Math.Sqrt((3 * a + b) * (a + 3 * b)));
            return p;
        }

        // 
        // Add the root nodes to the Display Element tree
        //
        static public void PopulateElementTree(TreeView tree)
        {
            foreach (ElementNode channel in VixenSystem.Nodes.GetRootNodes())
            {
                AddNodeToElementTree(tree.Nodes, channel);
            }
        }

        // 
        // Add each child Display Element or Display Element Group to the tree
        // 
        static private void AddNodeToElementTree(TreeNodeCollection collection, ElementNode channelNode)
        {
            TreeNode addedNode = new TreeNode();
            addedNode.Name = channelNode.Id.ToString();
            addedNode.Text = channelNode.Name;
            addedNode.Tag = channelNode;

            collection.Add(addedNode);

            foreach (ElementNode childNode in channelNode.Children)
            {
                AddNodeToElementTree(addedNode.Nodes, childNode);
            }
        }

    }
}
