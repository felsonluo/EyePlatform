using ComponentFactory.Krypton.Toolkit;
using Eye.DataModel.DataModel;
using Eye.PhotoManager.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eye.PhotoManager
{
    public partial class MainForm : KryptonForm
    {

        private Manager manager = new Manager();


        private static readonly string _snapshotPath = "snapshot";
        private static readonly string _mainPath = "photo";
        private static readonly int FixWidth = 160;

        //当前编辑的行
        private int EditIndex = -1;

        public MainForm()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var folder = this.textBox1.Text.Trim();

            if (folder.Length == 0 || !Directory.Exists(folder)) return;

            var thread = new Thread(new ParameterizedThreadStart(LoadPictures));

            this.button3.Enabled = false;

            thread.Start(folder);
        }

        /// <summary>
        /// 加载图片
        /// </summary>
        private void LoadPictures(object obj)
        {

            var foler = obj.ToString();

            Action<string> action = (data) =>
            {
                var pictures = Manager.GetPictureList(data);

                this.showPictures2Grid(pictures);

                this.button3.Enabled = true;
            };

            this.Invoke(action, foler);

        }

        /// <summary>
        /// 讲数据展示到表格
        /// </summary>
        /// <param name="pictures"></param>
        private void showPictures2Grid(List<Picture> pictures)
        {
            this.dataGridView1.Rows.Clear();

            this.EditIndex = -1;

            for (var i = 0; i < pictures.Count; i++)
            {
                var picture = pictures[i];

                var index = this.dataGridView1.Rows.Add();

                var row = this.dataGridView1.Rows[index];

                row = FillRowWithPicture(row, picture);
            }
        }

        /// <summary>
        /// 填充表格数据
        /// </summary>
        /// <param name="row"></param>
        /// <param name="picture"></param>
        /// <returns></returns>
        private DataGridViewRow FillRowWithPicture(DataGridViewRow row, Picture picture)
        {
            row.Cells[nameof(picture.Checked)].Value = false;
            row.Cells[nameof(picture.Id)].Value = picture.Id;
            row.Cells[nameof(picture.Name)].Value = picture.Name;
            row.Cells[nameof(picture.Path)].Value = picture.Path;
            row.Cells[nameof(picture.SnapshotPath)].Value = picture.SnapshotPath;
            row.Cells[nameof(picture.TakeTime)].Value = picture.TakeTime;
            row.Cells[nameof(picture.TakeLocation)].Value = picture.TakeLocation;
            row.Cells[nameof(picture.Size)].Value = picture.Size;
            row.Cells[nameof(picture.Tags1)].Value = picture.Tags1;
            row.Cells[nameof(picture.Tags2)].Value = picture.Tags2;
            row.Cells[nameof(picture.Description)].Value = picture.Description;

            return row;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        private Picture GetPicture(DataGridViewRow row)
        {
            var picture = new Picture();

            picture.Checked = bool.Parse(row.Cells[nameof(picture.Checked)].Value?.ToString());
            picture.Id = row.Cells[nameof(picture.Id)].Value?.ToString();
            picture.Name = row.Cells[nameof(picture.Name)].Value?.ToString();
            picture.Path = row.Cells[nameof(picture.Path)].Value?.ToString();
            picture.SnapshotPath = row.Cells[nameof(picture.SnapshotPath)].Value?.ToString();
            picture.TakeTime = DateTime.Parse(row.Cells[nameof(picture.TakeTime)].Value?.ToString());
            picture.TakeLocation = row.Cells[nameof(picture.TakeLocation)].Value?.ToString();
            picture.Size = double.Parse(row.Cells[nameof(picture.Size)].Value?.ToString());
            picture.Tags1 = row.Cells[nameof(picture.Tags1)].Value?.ToString();
            picture.Tags2 = row.Cells[nameof(picture.Tags2)].Value?.ToString();
            picture.Description = row.Cells[nameof(picture.Description)].Value?.ToString();
            picture.Row = row;

            return picture;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="picture"></param>
        private void FillPicture2Detail(Picture picture)
        {
            this.pictureBox2.ImageLocation = string.IsNullOrWhiteSpace(picture.SnapshotPath) ? picture.Path : picture.SnapshotPath;
            this.txtName.Text = picture.Name;
            this.txtDate.Text = picture.TakeTime.ToString("yyyy-MM-dd HH:mm:ss");
            this.txtLocation.Text = picture.TakeLocation;
            this.txtTags1.Text = picture.Tags1;
            this.txtTags2.Text = picture.Tags2;
            this.txtDescription.Text = picture.Description;

        }

        /// <summary>
        /// 获取图片
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private Image GetImage(string path)
        {
            //通过输入文件目录，文件模式，访问模式等参数，通过流打开文件
            var fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            //通过调用系统的画笔工具，画出一个Image类型的数据，传给pictureBox。
            var image = Bitmap.FromStream(fs);

            return image;
        }

        /// <summary>
        /// 获取选中的行
        /// </summary>
        /// <returns></returns>
        private List<DataGridViewRow> GetCheckedRows()
        {
            var list = new List<DataGridViewRow>();

            for (var i = 0; i < this.dataGridView1.Rows.Count; i++)
            {
                if (bool.Parse(this.dataGridView1.Rows[i].Cells["Checked"].Value.ToString()))
                    list.Add(this.dataGridView1.Rows[i]);
            }

            return list;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.folderBrowserDialog1.SelectedPath = this.textBox1.Text;
            this.folderBrowserDialog1.ShowDialog();
            this.textBox1.Text = this.folderBrowserDialog1.SelectedPath;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var picture = GetPicture(this.dataGridView1.Rows[e.RowIndex]);

            FillPicture2Detail(picture);

            this.EditIndex = e.RowIndex;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.dataGridView1.Rows.Count == 0) return;

            var isChecked = this.checkBox1.Checked;

            for (var i = 0; i < this.dataGridView1.Rows.Count; i++)
            {
                this.dataGridView1.Rows[i].Cells["Checked"].Value = isChecked;
            }
        }

        /// <summary>
        /// 保存图片信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            if (this.EditIndex == -1) return;

            var row = this.dataGridView1.Rows[this.EditIndex];

            FillRowWithEditData(row);

        }

        /// <summary>
        /// 把用户编辑好的数据更新
        /// </summary>
        /// <param name="row"></param>
        private void FillRowWithEditData(DataGridViewRow row)
        {
            var picture = new Picture();
            row.Cells[nameof(picture.Name)].Value = this.txtName.Text;
            row.Cells[nameof(picture.TakeTime)].Value = this.txtDate.Text;
            row.Cells[nameof(picture.TakeLocation)].Value = this.txtLocation.Text;
            row.Cells[nameof(picture.Tags1)].Value = this.txtTags1.Text;
            row.Cells[nameof(picture.Tags2)].Value = this.txtTags2.Text;
            row.Cells[nameof(picture.Description)].Value = this.txtDescription.Text;
        }

        /// <summary>
        /// <summary>
        /// 选择布标文件夹
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button7_Click(object sender, EventArgs e)
        {
            var result = this.folderBrowserDialog2.ShowDialog();

            if (result == DialogResult.OK)
            {
                this.textBox2.Text = this.folderBrowserDialog2.SelectedPath;
            }
        }

        /// <summary>
        /// 删除图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button6_Click(object sender, EventArgs e)
        {
            var pictures = this.GetCheckedPictures();

            if (pictures.Count == 0) return;

            var mess = MessageBoxButtons.OKCancel;
            DialogResult dr = MessageBox.Show("确定要删除" + pictures.Count + "条记录吗?", "提示", mess);
            if (dr == DialogResult.OK)
            {

                var count = Manager.DeletePictures(pictures);

                MessageBox.Show("删除了" + count + "条记录!");
            }
        }

        /// <summary>
        /// 获取图片列表
        /// </summary>
        /// <param name="rows"></param>
        /// <returns></returns>
        private List<Picture> GetPictures(List<DataGridViewRow> rows)
        {
            var pictures = new List<Picture>();

            if (rows != null && rows.Any())
            {
                rows.ForEach(x =>
                {
                    pictures.Add(GetPicture(x));
                });
            }

            return pictures;
        }

        /// <summary>
        /// 获取选中的图片
        /// </summary>
        /// <returns></returns>
        private List<Picture> GetCheckedPictures()
        {
            var selectedRows = this.GetCheckedRows();

            var pictures = GetPictures(selectedRows);

            return pictures;
        }

        /// <summary>
        /// 给所有的照片创建快照
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            var pictures = this.GetCheckedPictures();

            if (pictures.Count == 0) return;

            var count = Manager.ReducePictures(pictures, this.textBox2.Text + "\\" + _snapshotPath, FixWidth);

            for (var i = 0; i < pictures.Count; i++)
            {
                var picture = pictures[i];

                picture.Row.Cells[nameof(picture.SnapshotPath)].Value = picture.SnapshotPath;

            }

            MessageBox.Show("创建了" + count + "张图片快照!");

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                var isCheck = bool.Parse(this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());

                this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = isCheck ? false : true;
            }
        }

        /// <summary>
        /// 将图片全部转移到一个地方
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button8_Click(object sender, EventArgs e)
        {
            var pictures = this.GetCheckedPictures();

            if (pictures.Count == 0) return;

            var mess = MessageBoxButtons.OKCancel;
            DialogResult dr = MessageBox.Show("确定要转移" + pictures.Count + "条记录吗?", "提示", mess);
            if (dr == DialogResult.OK)
            {
                var path = this.textBox2.Text + "\\" + _mainPath;

                var count = Manager.MovePictures(pictures, path);

                MessageBox.Show("转移了" + count + "条记录!");

                this.button3_Click(sender, e);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (this.EditIndex == -1) return;

            SetTag(this.txtTags1, Manager.Tags1);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (this.EditIndex == -1) return;

            SetTag(this.txtTags2, Manager.Tags2);
        }

        /// <summary>
        /// 设置标签
        /// </summary>
        /// <param name="box"></param>
        private void SetTag(TextBox box, List<string> tags)
        {
            var tagList = string.IsNullOrWhiteSpace(this.txtTags2.Text) ? new List<string>() : this.txtTags2.Text.Split(',').ToList();

            var tagForm = new TagsSelector(tags, tagList);

            var result = tagForm.ShowDialog();

            if (result == DialogResult.OK)
            {
                tagList = tagForm.Tags;

                box.Text = string.Join(",", tagList);
            }
        }
    }
}
