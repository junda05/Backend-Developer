using System;
public class Program
{
    public static void Main()
    {
        Person person1 = new Person("Mauricio Unda", 21);
        Person person2 = new Person("María Pongutá", 21);

        person1.Greet();
        person2.Greet();
    }
}