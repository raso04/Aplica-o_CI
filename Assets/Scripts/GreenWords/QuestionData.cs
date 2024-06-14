using System;

[Serializable]
public class QuestionData
{
    public string palavra;
    public string dificuldade1;
    public string dificuldade2;
    public string dificuldade3;
    public string[] respostas = new string[4];


    // Constructor
    public QuestionData(string palavra, string dificuldade1, string dificuldade2, string dificuldade3,
                        string[] respostas)
    {
        this.palavra = palavra;
        this.dificuldade1 = dificuldade1;
        this.dificuldade2 = dificuldade2;
        this.dificuldade3 = dificuldade3;
        this.respostas = respostas;
    }

    // Method to shuffle a string array
    public static void ShuffleRespostas(string[] array)
    {
        Random rng = new Random();
        int n = array.Length;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            string value = array[k];
            array[k] = array[n];
            array[n] = value;
        }
    }
}