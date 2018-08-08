using ComponentFactory.Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eye.PhotoManager
{
    public partial class TagsSelector : KryptonForm
    {
        public List<string> Tags { get; protected set; }

        private List<string> SrcItems { get; set; }
        private List<string> TargetItems { get; set; }

        public TagsSelector(List<string> srcItems, List<string> targetItems)
        {
            InitializeComponent();

            this.SrcItems = srcItems;
            this.TargetItems = targetItems;

            this.FillItems();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="srcItems"></param>
        /// <param name="targetItems"></param>
        private void FillItems()
        {
            SrcItems.ForEach(x =>
            {
                if (!TargetItems.Contains(x))
                {
                    this.listBox1.Items.Add(x);
                }
            });
            TargetItems.ForEach(x => this.listBox2.Items.Add(x));
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Tags = ConvertItems2List(this.listBox2.Items);
            DialogResult = DialogResult.OK;
            this.Close();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        private List<string> ConvertItems2List(ListBox.ObjectCollection items)
        {
            var result = new List<string>();

            for (var i = 0; i < items.Count; i++)
            {
                result.Add(items[i].ToString());
            }

            return result;
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedItem = this.listBox1.SelectedItem;
            this.listBox1.Items.Add(selectedItem);
            this.listBox2.Items.Remove(selectedItem);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var selectedItem = this.listBox1.SelectedItem;
            this.listBox2.Items.Add(selectedItem);
            this.listBox1.Items.Remove(selectedItem);
        }
    }
}
