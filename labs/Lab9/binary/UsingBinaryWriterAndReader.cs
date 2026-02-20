using System.IO;
using System.Text;


#if trueq

struct State
{
    public string name;
    public string capital;
    public int area;
    public double people;

    public State(string n, string c, int a, double p)
    {
        name = n;
        capital = c;
        people = p;
        area = a;
    }
}

class UsingBinaryWriterAndReader
{
    static void Main()
    {
        State[] states = new State[2];
        states[0] = new State("Германия", "Берлин", 357168, 80.8);
        states[1] = new State("Франция", "Париж", 640679, 64.7);

        string path = @"C:/SomeDir/states.bat";
        try
        {
            using (BinaryWriter bw = new BinaryWriter(File.Open(path, FileMode.OpenOrCreate)))
            {
                foreach (State s in states)
                {
                    bw.Write(s.name);
                    bw.Write(s.capital);
                    bw.Write(s.area);
                    bw.Write(s.people);
                }
            }

            using (BinaryReader br = new BinaryReader(File.Open(path, FileMode.Open)))
            {
                while (br.PeekChar() != -1)
                {
                    string name = br.ReadString();
                    string capital = br.ReadString();
                    int area = br.ReadInt32();
                    double people = br.ReadDouble();

                    Console.WriteLine(
                        "Страна: {0}  столица: {1}  площадь {2} кв. км   численность населения: {3} млн. чел.",
                        name, capital, area, people);
                }
            }
        }
        catch (IOException e)
        {
            Console.WriteLine(e.Message);
        }

    }
}
#endif