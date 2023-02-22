using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Wpf_Diary
{
    public partial class MainWindow : Window
    {
        List<Note> filtered;
        int? note_index;

        public MainWindow()
        {
            InitializeComponent();
           
            Date.Text = DateTime.Today.ToString();
            List_by_date();
        }

        private void ButtonDelete(object sender, RoutedEventArgs e)
        {
            Note.notes.RemoveAt(Convert.ToInt32(note_index));
            note_index = null;
            List_by_date();
            De_Serialize.SerializeXML();
        }

        private void ButtonCreate(object sender, RoutedEventArgs e)
        {
            Note.Create_note(Convert.ToDateTime(Date.Text).Date, Note_name.Text, Note_description.Text);
            List_by_date();
            De_Serialize.SerializeXML();
        }

        private void ButtonSave(object sender, RoutedEventArgs e)
        {
            Note.Update_note(note_index, Convert.ToDateTime(Date.Text).Date, Note_name.Text, Note_description.Text);
            note_index = null;
            List_by_date();
            De_Serialize.SerializeXML();
        }

        private void Date_SelectedDateChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            Note_name.Text = "";
            Note_description.Text = "";
            List_by_date();
        }

        private void Notes_list_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (Notes_list.SelectedIndex >= 0)
            {
                for (int i = 0; i < Note.notes.Count(); i++)
                {
                    if (filtered[Notes_list.SelectedIndex].Date_note == Note.notes[i].Date_note)
                    {
                        if (filtered[Notes_list.SelectedIndex].Name == Note.notes[i].Name)
                        {
                            if (filtered[Notes_list.SelectedIndex].Text == Note.notes[i].Text)
                            {
                                note_index = i;
                                Note_name.Text = Note.notes[i].Name;
                                Note_description.Text = Note.notes[i].Text;
                            }
                        }
                    }
                }
            }
        }

        private void List_by_date()
        {
            filtered = Note.notes.Where(n => n.Date_note.Date == Convert.ToDateTime(Date.Text).Date).ToList();
            Notes_list.ItemsSource = null;
            Notes_list.ItemsSource = filtered;
        }
    }
}
