using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace A24_420CW6_TP3_6280636.Models
{
    public class Score
    {
        [Key]
        public int Id { get; set; }
        public string Pseudo { get; set; } = null!;
        public int scoreValue { get; set; }
        public string timeInSeconds { get; set; } = null!;

        [DataType(DataType.Date)]
        public DateTime? Date { get; set; }
        public bool IsPublic { get; set; }

        //public string UserId { get; set; } = null!;

        [JsonIgnore]
        public virtual User? User { get; set; }

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
