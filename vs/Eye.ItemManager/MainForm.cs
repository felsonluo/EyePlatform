﻿using ComponentFactory.Krypton.Toolkit;
using Eye.Common;
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
        private void showPictures2Grid(List<PictureModel> pictures)
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
        private DataGridViewRow FillRowWithPicture(DataGridViewRow row, PictureModel picture)
        {
            row.Cells[nameof(picture.EChecked)].Value = false;
            row.Cells[nameof(picture.EId)].Value = picture.EId;
            row.Cells[nameof(picture.EName)].Value = picture.EName;
            row.Cells[nameof(picture.EPath)].Value = picture.EPath;
            row.Cells[nameof(picture.ESnapshotPath)].Value = picture.ESnapshotPath;
            row.Cells[nameof(picture.ETakeTime)].Value = picture.ETakeTime;
            row.Cells[nameof(picture.ETakeLocation)].Value = picture.ETakeLocation;
            row.Cells[nameof(picture.ESize)].Value = picture.ESize;
            row.Cells[nameof(picture.ETags1)].Value = picture.ETags1;
            row.Cells[nameof(picture.ETags2)].Value = picture.ETags2;
            row.Cells[nameof(picture.EDescription)].Value = picture.EDescription;

            return row;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        private PictureModel GetPicture(DataGridViewRow row)
        {
            var picture = new PictureModel();

            picture.EChecked = bool.Parse(row.Cells[nameof(picture.EChecked)].Value?.ToString());
            picture.EId = row.Cells[nameof(picture.EId)].Value?.ToString();
            picture.EName = row.Cells[nameof(picture.EName)].Value?.ToString();
            picture.EPath = row.Cells[nameof(picture.EPath)].Value?.ToString();
            picture.ESnapshotPath = row.Cells[nameof(picture.ESnapshotPath)].Value?.ToString();
            picture.ETakeTime = DateTime.Parse(row.Cells[nameof(picture.ETakeTime)].Value?.ToString());
            picture.ETakeLocation = row.Cells[nameof(picture.ETakeLocation)].Value?.ToString();
            picture.ESize = double.Parse(row.Cells[nameof(picture.ESize)].Value?.ToString());
            picture.ETags1 = row.Cells[nameof(picture.ETags1)].Value?.ToString();
            picture.ETags2 = row.Cells[nameof(picture.ETags2)].Value?.ToString();
            picture.EDescription = row.Cells[nameof(picture.EDescription)].Value?.ToString();
            picture.ERow = row;

            return picture;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="picture"></param>
        private void FillPicture2Detail(PictureModel picture)
        {
            this.pictureBox2.ImageLocation = string.IsNullOrWhiteSpace(picture.ESnapshotPath) ? picture.EPath : picture.ESnapshotPath;
            this.txtName.Text = picture.EName;
            this.txtDate.Text = picture.ETakeTime.IsValid() ? picture.ETakeTime.ToString("yyyy-MM-dd HH:mm:ss") : "";
            this.txtLocation.Text = picture.ETakeLocation;
            this.txtTags1.Text = picture.ETags1;
            this.txtTags2.Text = picture.ETags2;
            this.txtDescription.Text = picture.EDescription;

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
                if (bool.Parse(this.dataGridView1.Rows[i].Cells["EChecked"].Value.ToString()))
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
                this.dataGridView1.Rows[i].Cells["EChecked"].Value = isChecked;
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
            var picture = new PictureModel();
            row.Cells[nameof(picture.EName)].Value = this.txtName.Text;
            row.Cells[nameof(picture.ETakeTime)].Value = this.txtDate.Text;
            row.Cells[nameof(picture.ETakeLocation)].Value = this.txtLocation.Text;
            row.Cells[nameof(picture.ETags1)].Value = this.txtTags1.Text;
            row.Cells[nameof(picture.ETags2)].Value = this.txtTags2.Text;
            row.Cells[nameof(picture.EDescription)].Value = this.txtDescription.Text;
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
        private List<PictureModel> GetPictures(List<DataGridViewRow> rows)
        {
            var pictures = new List<PictureModel>();

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
        private List<PictureModel> GetCheckedPictures()
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

                picture.ERow.Cells[nameof(picture.ESnapshotPath)].Value = picture.ESnapshotPath;

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
