using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CQRSExample.Models
{
    public class TodoItem
    {
        private TodoItem()
        {
        }

        public TodoItem(string name, bool isComplete)
        {
            Name = name;
            IsComplete = isComplete;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Key { get; private set; }
        public string Name { get; private set; }
        public bool IsComplete { get; private set; }
    }
}