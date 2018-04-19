using FormatPhoneNumberDataGridView.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormatPhoneNumberDataGridView
{
    public partial class Form1 : Form
    {
        private TestContext Context { get; set; }

        public Form1()
        {
            InitializeComponent();
            Context = new TestContext();
            // Add people
            foreach (Person p in Context.Contacts)
                Context.Contacts.Remove(p);
            Context.Contacts.Add(new Person
            {
                Id = Guid.NewGuid(),
                Name = "Paullus Nava",
                UnformattedPhone = "61999995555"
            });
            Context.Contacts.Add(new Person
            {
                Id = Guid.NewGuid(),
                Name = "Renan Xavier",
                UnformattedPhone = "11912341234"
            });
            Context.SaveChanges();
            DataGridView.AutoGenerateColumns = false;
            DataGridView.DataSource = Context.Contacts.ToList();
        }

        private void DataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                DataGridViewRow row = DataGridView.Rows[e.RowIndex];
                // nao entendi essa declaracao da variavel table (iniciante em C#)
                List<Person> people = (List<Person>)DataGridView.DataSource;
                row.Cells["FormattedPhone"].Value = "(" + people[e.RowIndex].UnformattedPhone.Substring(0, 2) + ") " +
                    people[e.RowIndex].UnformattedPhone.Substring(2, 5) + "-" +
                    people[e.RowIndex].UnformattedPhone.Substring(7);
            }
        }
    }
}
