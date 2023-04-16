using System;

namespace Assets.Sources.Domain
{
    public class Score
    {
        public event Action<int> Changed;
        
        public int Value { get; private set; } = 0;
        
        public void Add(int score)
        {
            if (score <= 0)
                return;

            Value += score;
            Changed?.Invoke(Value);
        }
    }
}