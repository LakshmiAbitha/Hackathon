using System.Runtime.CompilerServices;

namespace notesass
{
    class Note
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }

    }
    class Management
    {
        List<Note> notes=new List<Note>();
        public int customerid = 1;
        public void createnotes()
        {
            try
            {
                Console.WriteLine("Enter the title of note");
                string title = Console.ReadLine();
                Console.WriteLine("Enter the description of note");
                string description = Console.ReadLine();
                int id = customerid++;
                DateTime date = DateTime.Now;
                notes.Add(new Note() { Id = id, Title = title, Description = description, Date = date });
                Console.WriteLine("Notes is successful added");
            }
            catch(FormatException)
            {
                Console.WriteLine("Enter only strings");
            }
        }
        public Note Viewnote(int id)
        {
            foreach(Note note in notes)
            {
                if(note.Id == id) 
                    return note;
            }
            return null;
        }
        public List<Note> ViewAllnotes()
        {
            return notes;
        }
        public bool Updatenote(int id)
        {
            foreach (Note note in notes)
            {
                if(note.Id == id)
                {
                    try
                    {
                        Console.WriteLine("Enter note updated title");
                        note.Title = Console.ReadLine();
                        Console.WriteLine("Enter note updated description");
                        note.Description = Console.ReadLine();
                        return true;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("enter only strings");
                    }
                }
            }
            return false;
        }
        public bool Deletenote(int id)
        {
            foreach(Note note in notes)
            {
                if(note.Id == id)
                {
                    notes.Remove(note);
                    return true;
                }
            }
            return false;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Management obj= new Management();
            string res = "";
            do
            {
                Console.WriteLine("1. Create Note");
                Console.WriteLine("2. View Note By Id");
                Console.WriteLine("3. View All Note");
                Console.WriteLine("4.Update Note by Id");
                Console.WriteLine("5. Delete Note by Id");
                Console.WriteLine("Enter your choice");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        {
                            obj.createnotes();
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("Enter  the note Id");
                            int id = Convert.ToInt32(Console.ReadLine());
                            Note? n = obj.Viewnote(id);
                            if (n == null)
                            {
                                Console.WriteLine("Note With specific id not exists");
                            }
                            else
                            {
                                Console.WriteLine($"Id- {n.Id} title:{n.Title} Description:{n.Description} date:{n.Date}");
                            }
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("Id\t Title\t Description\t Date");
                            int count = 0;
                            foreach (var n in obj.ViewAllnotes())
                            {
                                Console.WriteLine($"{n.Id}\t{n.Title}\t{n.Description}\t\t{n.Date}");
                                count++;
                            }
                            Console.WriteLine($"Total notes\t{count}");
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("Enter the note id");
                            int id = Convert.ToInt32(Console.ReadLine());
                            if (obj.Updatenote(id))
                            {
                                Console.WriteLine("note updated  successfully");
                            }
                            else
                            {
                                Console.WriteLine("note not exist");
                            }
                            break;
                        }
                    case 5:
                        {
                            Console.WriteLine("enter the note id");
                            int id = Convert.ToInt32(Console.ReadLine());
                            if (obj.Deletenote(id))
                            {
                                Console.WriteLine("Note Deleted Successfully");
                            }
                            else
                            {
                                Console.WriteLine("Note not exist");
                            }
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Invlaid choice");
                            break;
                        }
                }
                Console.WriteLine("Do you wish to continue[y/n]");
                res = Console.ReadLine();
            } while (res.ToLower() == "y");
        }
    }
}