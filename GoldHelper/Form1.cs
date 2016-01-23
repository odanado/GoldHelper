using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoldHelper
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            init();
        }

        void init()
        {
            goldHelper = new GoldHelper();
            goldHelper.pokemon.BaseStats = new Stats(50, 65, 64, 43, 44, 48);
        }

        private Button[] BTN_HP;
        private Button[] BTN_Atk;
        private Button[] BTN_Def;
        private Button[] BTN_Spd;
        private Button[] BTN_Spc;

        private Button prevPushedBTN;

        private GoldHelper goldHelper;

        private Label makeLabel(String text, Font font, Point location, int width, int height)
        {
            Label label = new Label();
            label.Text = text;
            label.Font = font;
            label.Location = location;
            label.Width = width;
            label.Height = height;
            label.TextAlign = ContentAlignment.BottomCenter;

            return label;
        }

        private Button makeButton(String text, Font font, Point location, int width)
        {

            var button = new Button();
            button.Text = text;
            button.Font = font;
            button.Location = location;
            button.Width = width;

            return button;
        }

        private void initButtons()
        {
            BTN_HP = new Button[16];
            BTN_Atk = new Button[16];
            BTN_Def = new Button[16];
            BTN_Spd = new Button[16];
            BTN_Spc = new Button[16];
            Point offset = new Point(5, 30);
            int height = 25;
            Font font = new Font("メイリオ", 9);

            for (int i = 0; i < 16; i++)
            {

                BTN_HP[i] = makeButton("00", font, new Point(offset.X + 20, offset.Y + height * i), 50);
                BTN_Atk[i] = makeButton("00", font, new Point(offset.X + 20, offset.Y + height * i), 50);
                BTN_Def[i] = makeButton("00", font, new Point(offset.X + 20, offset.Y + height * i), 50);
                BTN_Spd[i] = makeButton("00", font, new Point(offset.X + 20, offset.Y + height * i), 50);
                BTN_Spc[i] = makeButton("00", font, new Point(offset.X + 20, offset.Y + height * i), 50);

                BTN_HP[i].Click += new EventHandler(BTN_HP_Click);
                BTN_Atk[i].Click += new EventHandler(BTN_Atk_Click);
                BTN_Def[i].Click += new EventHandler(BTN_Def_Click);
                BTN_Spd[i].Click += new EventHandler(BTN_Spd_Click);
                BTN_Spc[i].Click += new EventHandler(BTN_Spc_Click);

                Panel_HP.Controls.Add(BTN_HP[i]);
                Panel_Atk.Controls.Add(BTN_Atk[i]);
                Panel_Def.Controls.Add(BTN_Def[i]);
                Panel_Spd.Controls.Add(BTN_Spd[i]);
                Panel_Spc.Controls.Add(BTN_Spc[i]);


                Panel_HP.Controls.Add(makeLabel(String.Format("{0,2}", i), font, new Point(5, offset.Y + height * i), 22, BTN_HP[i].Height));
                Panel_Atk.Controls.Add(makeLabel(String.Format("{0,2}", i), font, new Point(5, offset.Y + height * i), 22, BTN_Atk[i].Height));
                Panel_Def.Controls.Add(makeLabel(String.Format("{0,2}", i), font, new Point(5, offset.Y + height * i), 22, BTN_Def[i].Height));
                Panel_Spd.Controls.Add(makeLabel(String.Format("{0,2}", i), font, new Point(5, offset.Y + height * i), 22, BTN_Spd[i].Height));
                Panel_Spc.Controls.Add(makeLabel(String.Format("{0,2}", i), font, new Point(5, offset.Y + height * i), 22, BTN_Spc[i].Height));

            }

        }

        private void updateIVText()
        {
            Button[][] buttons = new Button[][] { BTN_HP, BTN_Atk, BTN_Def, BTN_Spd, BTN_Spc };
            for (int i = 0; i < buttons.Length; i++)
            {
                var button = buttons[i];
                for (int iv = 0; iv < 16; iv++)
                {
                    goldHelper.pokemon.IV[i] = iv;
                    goldHelper.pokemon.update();
                    string text = goldHelper.pokemon.Stats[i].ToString();
                    if (i + 1 == buttons.Length)
                    {
                        text += "/" + goldHelper.pokemon.Stats[i + 1].ToString();
                    }
                    button[iv].Text = text;
                    if (goldHelper.ivManager[i].get(iv)) button[iv].Show();
                    if (!goldHelper.ivManager[i].get(iv)) button[iv].Hide();
                }
            }

            L_HP.Text = String.Format(" HP\r\n{0}", goldHelper.ivManager.HP.getValidRange());
            L_Atk.Text = String.Format(" ATK\r\n{0}", goldHelper.ivManager.Atk.getValidRange());
            L_Def.Text = String.Format(" DEF\r\n{0}", goldHelper.ivManager.Def.getValidRange());
            L_Spd.Text = String.Format(" SPD\r\n{0}", goldHelper.ivManager.Spd.getValidRange());
            L_Spc.Text = String.Format(" SPC\r\n{0}", goldHelper.ivManager.Spc.getValidRange());
        }

        private void updateStatsText()
        {
            L_Level.Text = String.Format("Level: {0}", goldHelper.pokemon.Level);
        }

        private void changeBTNColor(Button pushedBTN)
        {
            if (pushedBTN == prevPushedBTN)
            {
                pushedBTN.BackColor = Color.LightBlue;
            }
            else
            {
                if (prevPushedBTN != null)
                    prevPushedBTN.BackColor = SystemColors.Control;
                pushedBTN.BackColor = Color.Yellow;
            }
            prevPushedBTN = pushedBTN;
        }

        private void BTN_HP_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            goldHelper.updateHP(Convert.ToInt32(btn.Text));
            updateIVText();
        }

        private void BTN_Atk_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            goldHelper.updateAtk(Convert.ToInt32(btn.Text));
            updateIVText();
        }

        private void BTN_Def_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            goldHelper.updateDef(Convert.ToInt32(btn.Text));
            updateIVText();
        }

        private void BTN_Spd_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            goldHelper.updateSpd(Convert.ToInt32(btn.Text));
            updateIVText();
        }

        private void BTN_Spc_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            var str = btn.Text.Split(new Char[] { '/' });

            goldHelper.updateSpAtk(Convert.ToInt32(str[0]));
            goldHelper.updateSpDef(Convert.ToInt32(str[1]));
            updateIVText();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            initButtons();
            updateIVText();
            updateStatsText();

        }

        private void BTN_PidgeyL2_Click(object sender, EventArgs e)
        {
            goldHelper.kill(Enemy.Name.Pidgey, 2, true);
            updateIVText();
            updateStatsText();
            changeBTNColor((Button)sender);
        }

        private void BTN_PidgeyL3_Click(object sender, EventArgs e)
        {
            goldHelper.kill(Enemy.Name.Pidgey, 3, true);
            updateIVText();
            updateStatsText();
            changeBTNColor((Button)sender);
        }

        private void BTN_PidgeyL4_Click(object sender, EventArgs e)
        {
            goldHelper.kill(Enemy.Name.Pidgey, 4, true);
            updateIVText();
            updateStatsText();
            changeBTNColor((Button)sender);
        }

        private void BTN_SentretL2_Click(object sender, EventArgs e)
        {
            goldHelper.kill(Enemy.Name.Sentret, 2, true);
            updateIVText();
            updateStatsText();
            changeBTNColor((Button)sender);
        }

        private void BTN_SentretL3_Click(object sender, EventArgs e)
        {
            goldHelper.kill(Enemy.Name.Sentret, 3, true);
            updateIVText();
            updateStatsText();
            changeBTNColor((Button)sender);
        }

        private void BTN_RattataL4_Click(object sender, EventArgs e)
        {
            goldHelper.kill(Enemy.Name.Rattata, 4, true);
            updateIVText();
            updateStatsText();
            changeBTNColor((Button)sender);
        }

        private void BTN_CaterpieL3_Click(object sender, EventArgs e)
        {
            goldHelper.kill(Enemy.Name.Caterpie, 3, true);
            updateIVText();
            updateStatsText();
            changeBTNColor((Button)sender);
        }

        private void BTN_CaterpieL4_Click(object sender, EventArgs e)
        {
            goldHelper.kill(Enemy.Name.Caterpie, 4, true);
            updateIVText();
            updateStatsText();
            changeBTNColor((Button)sender);
        }

        private void BTN_GeodudeL6_Click(object sender, EventArgs e)
        {
            goldHelper.kill(Enemy.Name.Geodude, 6, true);
            updateIVText();
            updateStatsText();
            changeBTNColor((Button)sender);
        }

        private void BTN_SandshrewL6_Click(object sender, EventArgs e)
        {
            goldHelper.kill(Enemy.Name.Sandshrew, 6, true);
            updateIVText();
            updateStatsText();
            changeBTNColor((Button)sender);
        }

        private void BTN_OnixL6_Click(object sender, EventArgs e)
        {
            goldHelper.kill(Enemy.Name.Onix, 6, true);
            updateIVText();
            updateStatsText();
            changeBTNColor((Button)sender);
        }

        private void BTN_ZubatL5_Click(object sender, EventArgs e)
        {
            goldHelper.kill(Enemy.Name.Zubat, 5, true);
            updateIVText();
            updateStatsText();
            changeBTNColor((Button)sender);
        }

        private void BTN_ZubatL6_Click(object sender, EventArgs e)
        {
            goldHelper.kill(Enemy.Name.Zubat, 6, true);
            updateIVText();
            updateStatsText();
            changeBTNColor((Button)sender);
        }

        private void BTN_RIVALChikoritaL5_Click(object sender, EventArgs e)
        {
            goldHelper.kill(Enemy.Name.Chikorita, 5, false);
            updateIVText();
            updateStatsText();
            changeBTNColor((Button)sender);
        }

        private void BTN_MIKEYPidgeyL2_Click(object sender, EventArgs e)
        {
            goldHelper.kill(Enemy.Name.Pidgey, 2, false);
            updateIVText();
            updateStatsText();
            changeBTNColor((Button)sender);
        }

        private void BTN_MIKEYRattataL4_Click(object sender, EventArgs e)
        {
            goldHelper.kill(Enemy.Name.Rattata, 4, false);
            updateIVText();
            updateStatsText();
            changeBTNColor((Button)sender);
        }

        private void BTN_DONCaterpieL3_Click(object sender, EventArgs e)
        {
            goldHelper.kill(Enemy.Name.Caterpie, 3, false);
            updateIVText();
            updateStatsText();
            changeBTNColor((Button)sender);
        }

        private void BTN_DONCaterpieL3_2_Click(object sender, EventArgs e)
        {
            goldHelper.kill(Enemy.Name.Caterpie, 3, false);
            updateIVText();
            updateStatsText();
            changeBTNColor((Button)sender);
        }

        private void BTN_ABESpearowL9_Click(object sender, EventArgs e)
        {
            goldHelper.kill(Enemy.Name.Spearow, 9, false);
            updateIVText();
            updateStatsText();
            changeBTNColor((Button)sender);
        }

        private void BTN_RODPidgeyL7_Click(object sender, EventArgs e)
        {
            goldHelper.kill(Enemy.Name.Pidgey, 7, false);
            updateIVText();
            updateStatsText();
            changeBTNColor((Button)sender);
        }

        private void BTN_RODPidgeyL7_2_Click(object sender, EventArgs e)
        {
            goldHelper.kill(Enemy.Name.Pidgey, 7, false);
            updateIVText();
            updateStatsText();
            changeBTNColor((Button)sender);
        }

        private void BTN_FALKNERPidgeyL7_Click(object sender, EventArgs e)
        {
            goldHelper.kill(Enemy.Name.Pidgey, 7, false);
            updateIVText();
            updateStatsText();
            changeBTNColor((Button)sender);
        }

        private void BTN_FALKNERPidgeottoL9_Click(object sender, EventArgs e)
        {
            goldHelper.kill(Enemy.Name.Pidgeotto, 9, false);
            updateIVText();
            updateStatsText();
            changeBTNColor((Button)sender);
        }

        private void BTN_ALBERTRattataL7_Click(object sender, EventArgs e)
        {
            goldHelper.kill(Enemy.Name.Rattata, 7, false);
            updateIVText();
            updateStatsText();
            changeBTNColor((Button)sender);
        }

        private void BTN_ALBERTZubatL8_Click(object sender, EventArgs e)
        {
            goldHelper.kill(Enemy.Name.Zubat, 8, false);
            updateIVText();
            updateStatsText();
            changeBTNColor((Button)sender);
        }

        private void BTN_RALPHGoldeenL10_Click(object sender, EventArgs e)
        {
            goldHelper.kill(Enemy.Name.Geodude, 10, false);
            updateIVText();
            updateStatsText();
            changeBTNColor((Button)sender);
        }

        private void BTN_DANIELOnixL11_Click(object sender, EventArgs e)
        {
            goldHelper.kill(Enemy.Name.Onix, 11, false);
            updateIVText();
            updateStatsText();
            changeBTNColor((Button)sender);
        }

        private void BTN_RUSSELLGeodudeL4_Click(object sender, EventArgs e)
        {
            goldHelper.kill(Enemy.Name.Geodude, 4, false);
            updateIVText();
            updateStatsText();
            changeBTNColor((Button)sender);
        }

        private void BTN_RUSSELLGeodudeL6_Click(object sender, EventArgs e)
        {
            goldHelper.kill(Enemy.Name.Geodude, 6, false);
            updateIVText();
            updateStatsText();
            changeBTNColor((Button)sender);
        }

        private void BTN_RUSSELLGeodudeL8_Click(object sender, EventArgs e)
        {
            goldHelper.kill(Enemy.Name.Geodude, 8, false);
            updateIVText();
            updateStatsText();
            changeBTNColor((Button)sender);
        }

        private void BTN_BILLKoffingL6_Click(object sender, EventArgs e)
        {
            goldHelper.kill(Enemy.Name.Koffing, 6, false);
            updateIVText();
            updateStatsText();
            changeBTNColor((Button)sender);
        }

        private void BTN_BILLKoffingL6_2_Click(object sender, EventArgs e)
        {
            goldHelper.kill(Enemy.Name.Koffing, 6, false);
            updateIVText();
            updateStatsText();
            changeBTNColor((Button)sender);
        }

        private void BTN_RAYVulpixL9_Click(object sender, EventArgs e)
        {
            goldHelper.kill(Enemy.Name.Vulpix, 9, false);
            updateIVText();
            updateStatsText();
            changeBTNColor((Button)sender);
        }

        private void BTN_ANTHONYGeodudeL11_Click(object sender, EventArgs e)
        {
            goldHelper.kill(Enemy.Name.Geodude, 11, false);
            updateIVText();
            updateStatsText();
            changeBTNColor((Button)sender);
        }

        private void BTN_ANTHONYMachopL11_Click(object sender, EventArgs e)
        {
            goldHelper.kill(Enemy.Name.Machop, 11, false);
            updateIVText();
            updateStatsText();
            changeBTNColor((Button)sender);
        }

        private void BTN_GRUNT1RattataL9_Click(object sender, EventArgs e)
        {
            goldHelper.kill(Enemy.Name.Rattata, 9, false);
            updateIVText();
            updateStatsText();
            changeBTNColor((Button)sender);
        }

        private void BTN_GRUNT1RattataL9_2_Click(object sender, EventArgs e)
        {
            goldHelper.kill(Enemy.Name.Rattata, 9, false);
            updateIVText();
            updateStatsText();
            changeBTNColor((Button)sender);
        }

        private void BTN_GRUNT2ZubatL9_Click(object sender, EventArgs e)
        {
            goldHelper.kill(Enemy.Name.Zubat, 9, false);
            updateIVText();
            updateStatsText();
            changeBTNColor((Button)sender);
        }

        private void BTN_GRUNT2EkansL11_Click(object sender, EventArgs e)
        {
            goldHelper.kill(Enemy.Name.Ekans, 11, false);
            updateIVText();
            updateStatsText();
            changeBTNColor((Button)sender);
        }

        private void BTN_GRUNT3RattataL7_Click(object sender, EventArgs e)
        {
            goldHelper.kill(Enemy.Name.Rattata, 7, false);
            updateIVText();
            updateStatsText();
            changeBTNColor((Button)sender);
        }

        private void BTN_GRUNT3ZubatL9_Click(object sender, EventArgs e)
        {
            goldHelper.kill(Enemy.Name.Zubat, 9, false);
            updateIVText();
            updateStatsText();
            changeBTNColor((Button)sender);
        }

        private void BTN_GRUNT3ZubatL9_2_Click(object sender, EventArgs e)
        {
            goldHelper.kill(Enemy.Name.Zubat, 9, false);
            updateIVText();
            updateStatsText();
            changeBTNColor((Button)sender);
        }

        private void BTN_GRUNT4KoffingL14_Click(object sender, EventArgs e)
        {
            goldHelper.kill(Enemy.Name.Koffing, 14, false);
            updateIVText();
            updateStatsText();
            changeBTNColor((Button)sender);
        }

        private void BTN_Reset_Click(object sender, EventArgs e)
        {
            init();
            updateIVText();
            updateStatsText();
            if (prevPushedBTN != null) prevPushedBTN.BackColor = SystemColors.Control;
        }

        private void BTN_Dump_Click(object sender, EventArgs e)
        {
            string text;
            text = "Ctrl+Cでコピー可能\r\n\r\n";
            text += goldHelper.ToString();
            MessageBox.Show(text, BTN_Dump.Text, MessageBoxButtons.OK);
        }
    }
}
