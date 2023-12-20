using ExplorerProMax.Core;
using ExplorerProMax.Core.PathEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExplorerProMax.UI
{
    public partial class SearchForm : Form
    {
        public FileExplorer Explorer { get; private set; }

        public List<IFileSystemEntity> SearchResult { get; private set; }

        public SearchForm(FileExplorer explorer)
        {
            Explorer = explorer;
            InitializeComponent();
            lLocation.Text = explorer.CurrentWorkingDirectory.FullPath;
        }


        private void bCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void bSearch_Click(object sender, EventArgs e)
        {
            if (tbTemplate.Text == String.Empty || tbTemplate.Text == " ")
                return;
            SearchResult = Explorer.Serarch(tbTemplate.Text, cbIncludeSubDirectories.Checked, cbStrictSearch.Checked);
            if(SearchResult.Count > 0)
                DialogResult = DialogResult.OK;
            else
            {
                MessageBox.Show($"Не вдалось знайти файли за шаблоном\n{tbTemplate.Text}", "Нічого не знайдено", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.Cancel;
            }
            Close();
        }
    }
}
