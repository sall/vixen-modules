using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VixenModules.App.LightShowScheduler.Controls
{
    internal static class Extensions
    {
        internal static void MoveSelectedItemUp(this ListBox lstBox)
        {
            var item = lstBox.SelectedItem;
            var index = lstBox.SelectedIndex;
            if (index >= 0)
            {
                lstBox.Items.RemoveAt(index);
                index--;
                if (index < 0)
                    index = 0;
                lstBox.Items.Insert(index, item);
            }
            lstBox.SelectedItem = item;
        }

        internal static void MoveSelectedItemDown(this ListBox lstBox)
        {

            var item = lstBox.SelectedItem;
            var index = lstBox.SelectedIndex;

            if (index >= 0)
            {
                lstBox.Items.RemoveAt(index);
                index++;

                if (index > lstBox.Items.Count)
                    index = lstBox.Items.Count;

                lstBox.Items.Insert(index, item);
            }
            lstBox.SelectedItem = item;
        }

        internal static void MoveSelectedItemToListBox(this ListBox from, ListBox to)
        {
            if (from.SelectedItem != null)
            {
                to.Items.Add(from.SelectedItem);

                from.Items.Remove(from.SelectedItem);
            }

        }

        internal static void RemoveSelectedItem(this ListBox from)
        {
            if (from.SelectedItem != null)
            {

                from.Items.Remove(from.SelectedItem);
            }

        }

        internal static void CopySelectedItemToListBox(this ListBox from, ListBox to)
        {
            if (from.SelectedItem != null)
            {
                to.Items.Add(from.SelectedItem);
            }
        }
    }
}
