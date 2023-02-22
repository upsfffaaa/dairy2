using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Wpf_Diary
{
    internal class De_Serialize
    {
        public static void DeserializeXML()
        {
            XmlSerializer xml = new XmlSerializer(typeof(List<Note>));
            using (FileStream fs = new FileStream(path: @"C:\db.xml", FileMode.Open))
            {
                List<Note>? readNotes = xml.Deserialize(fs) as List<Note>;
                foreach (Note note in readNotes)
                {
                    Note.notes.Add(note);
                }
            }
        }
        public static void SerializeXML()
        {
            XmlSerializer xml = new XmlSerializer(typeof(List<Note>));
            using (FileStream fs = new FileStream(path: @"C:\db.xml", FileMode.OpenOrCreate))
            {
                xml.Serialize(fs, Note.notes);
            }
        }
    }
}
