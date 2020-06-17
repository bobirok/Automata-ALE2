﻿namespace ALE2.Models
{
    public class TransitionStackElement
    {
        public Letter inLetter { get; }
        public Letter outLetter { get; }

        public TransitionStackElement(Letter inLetter, Letter outLetter)
        {
            this.inLetter = inLetter;
            this.outLetter = outLetter;
        }
    }
}
