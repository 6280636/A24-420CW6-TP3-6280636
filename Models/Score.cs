namespace A24_420CW6_TP3_6280636.Models
{
    public class Score
    {
        public int Id { get; set; }
        public string Pseudo { get; set; }
        public int scoreValue { get; set; }
        public TimeSpan Temp { get; set; }
        public DateTime Date { get; set; }
        public bool Visibilite { get; set; }

        //public Score(int id, string pseudo, int score, TimeSpan temp, DateTime date) 
        //{
        //    Id = id;
        //    Pseudo = pseudo;
        //    scoreValue = score;
        //    Temp = temp;
        //    Date = date;
        //    Visibilite = false;
        //}

    }
}
