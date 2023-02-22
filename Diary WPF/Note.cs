using System;
using System.Collections.Generic;

namespace Wpf_Diary
{
    public class Note
    {
        public DateTime Date_note;
        public string Name { get; set; }
        public string Text { get; set; }

        public override string ToString()
        {
            return Name;
        }

        public static List<Note> notes = new List<Note>();



        public static void Create_note(DateTime Date_note, string Name, string Text)
        {
            Note new_note = new();
            new_note.Date_note = Date_note;
            new_note.Name = Name;
            new_note.Text = Text;

            notes.Add(new_note);
        }

        public static void Update_note(int? note_index, DateTime Date_note, string Name, string Text)
        {
            Note updated_note= new();
            updated_note.Date_note = Date_note;
            updated_note.Name = Name;
            updated_note.Text = Text;

            notes[Convert.ToInt32(note_index)] = updated_note;
        }
    }
}
