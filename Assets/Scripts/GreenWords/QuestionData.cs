using System;

[Serializable]
public class QuestionData
{
    public string palavra;
    public string dificuldade1;
    public string dificuldade2;
    public string dificuldade3;
    public string[] respostas1 = new string[4];
    public string[] respostas2 = new string[4];
    public string[] respostas3 = new string[4];
    public string certa1;
    public string certa2;
    public string certa3;

    // Constructor
    public QuestionData(string palavra, string dificuldade1, string dificuldade2, string dificuldade3,
                        string[] respostas1, string[] respostas2, string[] respostas3,
                        string certa1, string certa2, string certa3)
    {
        this.palavra = palavra;
        this.dificuldade1 = dificuldade1;
        this.dificuldade2 = dificuldade2;
        this.dificuldade3 = dificuldade3;
        this.respostas1 = respostas1;
        this.respostas2 = respostas2;
        this.respostas3 = respostas3;
        this.certa1 = certa1;
        this.certa2 = certa2;
        this.certa3 = certa3;
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