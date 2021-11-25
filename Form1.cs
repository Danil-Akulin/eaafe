using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormElements
{
    public partial class Form1 : Form
    {
        TreeView tree;
        Button btn;
        Label lbl;
        CheckBox box_lbl, box_btn;
        RadioButton r1, r2;
        TextBox txt_box;
        PictureBox picture;
        TabControl tabC;
        public Form1()
        {
            this.Height = 600;
            this.Width = 800;
            this.Text = "Vorm elementidega";
            tree = new TreeView();
            tree.Dock = DockStyle.Left;
            tree.AfterSelect += Tree_AfterSelect;
            TreeNode tn = new TreeNode("Elemendid");
            tn.Nodes.Add(new TreeNode("Nupp-Button"));
            //button
            btn = new Button();
            btn.Text = "Vajuta siia";
            btn.Location = new Point(200, 100);
            btn.Height = 40;
            btn.Width = 120;
            btn.Click += Btn_Click;
            //
            tn.Nodes.Add(new TreeNode("Silt-Label"));
            //label
            lbl = new Label();
            lbl.Text = "Tarkvara arendajad";
            lbl.Size = new Size(150, 30);
            lbl.Location = new Point(150, 200);
            //
            tn.Nodes.Add(new TreeNode("Märkeruut-CheckBox"));
            tn.Nodes.Add(new TreeNode("Radionupp-Radiobutton"));
            tn.Nodes.Add(new TreeNode("Tekstkast-TextBox"));
            tn.Nodes.Add(new TreeNode("PictureBox"));
            tn.Nodes.Add(new TreeNode("Kaart-TabControl"));
            tn.Nodes.Add(new TreeNode("MessageBox"));

            tree.Nodes.Add(tn);
            this.Controls.Add(tree);
        }

        private void Tree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Text == "Nupp-Button")
            {

                this.Controls.Add(btn);
            }
            else if (e.Node.Text == "Silt-Label")
            {

                this.Controls.Add(lbl);
            }
            else if (e.Node.Text == "Märkeruut-CheckBox")
            {
                box_btn = new CheckBox();
                box_btn.Text = "Näita nupp";
                box_btn.Location = new Point(200, 30);
                this.Controls.Add(box_btn);
                box_lbl = new CheckBox();
                box_lbl.Text = "Näita silt";
                box_lbl.Location = new Point(200, 70);
                this.Controls.Add(box_lbl);
                box_btn.CheckedChanged += Box_btn_CheckedChanged;
            }
            else if (e.Node.Text == "Radionupp-Radiobutton")
            {
                r1 = new RadioButton();
                r1.Text = "nupp vasakule";
                r1.Location = new Point(300, 30);
                r1.CheckedChanged += new EventHandler(Radiobuttons_Changed);
                r2 = new RadioButton();
                r2.Text = "nupp paremale";
                r2.Location = new Point(300, 70);
                r2.CheckedChanged += new EventHandler(Radiobuttons_Changed);
                this.Controls.Add(r1);
                this.Controls.Add(r2);
            }
            else if (e.Node.Text == "Tekstkast-TextBox")
            {
                txt_box = new TextBox();
                txt_box.Multiline = true;
                txt_box.Text = "Failist";
                txt_box.Location = new Point(300, 300);
                txt_box.Width = 100;
                txt_box.Height = 100;
            }
            else if (e.Node.Text == "PictureBox")
            {
                picture = new PictureBox();
                picture.Image = new Bitmap("Hoi.png");
                picture.Location = new Point(500, 10);
                picture.Size = new Size(90, 90);
                picture.SizeMode = PictureBoxSizeMode.Zoom;
                picture.BorderStyle = BorderStyle.Fixed3D;
                this.Controls.Add(picture);
            }
            else if (e.Node.Text == "Kaart-TabControl")
            {
                TabControl tabC= new TabControl();
                tabC.Location = new Point(450, 300);
                tabC.Size = new Size(300, 200);
                TabPage tabP1 = new TabPage("TTHK");
                WebBrowser wb = new WebBrowser();
                wb.Url=new Uri("https://www.tthk.ee/");
                tabP1.Controls.Add(wb);
                TabPage tabP2 = new TabPage("Teine");

                TabPage tabP3 = new TabPage("Kolmas");
                tabP3.DoubleClick += TabP3_DoubleClick;
                tabC.Controls.Add(tabP1);
                tabC.Controls.Add(tabP2);
                tabC.Controls.Add(tabP3);
                this.Controls.Add(tabC);
                tabC.Selected += TabC_Selected;
                tabC.DoubleClick += TabC_DoubleClick;

                tabC.Controls.Add(tabP1);
                tabC.Controls.Add(tabP2);
                tabC.Controls.Add(tabP3);
                this.Controls.Add(tabC);
            }
            else if (e.Node.Text == "MessageBox")
            {/*
                MessageBox.Show("MessageBox", "Kõige lihtsam aken");
                var answer = MessageBox.Show("Tahad InputBoxi näha?", "Aken koos nupudega", MessageBoxButtons.YesNo);
                if (answer == DialogResult.Yes)
                {
                    string text = Interaction.InputBox("Sisesta siia mingi tekst", "InputBox", "Mingi tekst");
                    if (MessageBox.Show("Kas tahad tekst saada Tekskastisse?", "Teksti salvestamine", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        lbl.Text = text;
                        Controls.Add(lbl);
                    }
                }
                */
            }
        }
        private void TabC_Selected(object sender, TabControlEventArgs e)
        {
            this.tabC.TabPages.Remove(tabC.SelectedTab);
        }
        private void TabC_DoubleClick(object sender, EventArgs e)
        {
            string title = "tabP" + (tabC.TabCount + 1).ToString();
            TabPage tb = new TabPage(title);
            tabC.TabPages.Add(tb);
        }
        private void Radiobuttons_Changed(object sender, EventArgs e)
        {
            if (r1.Checked)
            {
                btn.Location = new Point(150, 100);
            }
            else if (r2.Checked)
            {
                btn.Location = new Point(400, 100);
            }
        }
        private void Box_btn_CheckedChanged(object sender, EventArgs e)
        {
            if (box_btn.Checked)
            {
                Controls.Add(btn);
            }
            else
            {
                Controls.Remove(btn);
            }
        }
        private void Btn_Click(object sender, EventArgs e)
        {
            if (btn.BackColor == Color.White)
            {
                btn.BackColor = Color.White;
                lbl.BackColor = Color.White;
                lbl.ForeColor = Color.White;
            }
            else
            {
                btn.BackColor = Color.White;
                lbl.BackColor = Color.Black;
                lbl.ForeColor = Color.Black;
            }
        }
        private void TabP3_DoubleClick(object sender, EventArgs e)
        {
            string title = "tabP" + (tabC.TabCount + 1).ToString();
            TabPage tb = new TabPage(title);
            tabC.TabPages.Add(tb);
        }
        /*private void r_btn_Checked(object sender, EventArgs e)
        {
            if (r_btn1.Checked)
            {
                this.BackColor = Color.Black;
            }
        }*/
    }
}
