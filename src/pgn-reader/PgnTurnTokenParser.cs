namespace PgnReader
{
    public class PgnTurnTokenParser
    {

        public static PgnTurnTokenTypes GetTokenType(string token)
        {
            if (token.StartsWith("{")) return PgnTurnTokenTypes.AnnotationStart;
            if (token.EndsWith("}")) return PgnTurnTokenTypes.AnnotationEnd;
            if (token.ToInt() > 0) return PgnTurnTokenTypes.TurnStart;
            if (ParseResult(token) == PgnGameResult.Unknown) return PgnTurnTokenTypes.Notation;

            return PgnTurnTokenTypes.GameResult;
        }

        public static PgnGameResult ParseResult(string tagPair)
        {
            if (tagPair == "1/2-1/2") return PgnGameResult.Draw;
            if (tagPair == "1-0") return PgnGameResult.WhiteWins;
            if (tagPair == "0-1") return PgnGameResult.BlackWins;
            if (tagPair == "*") return PgnGameResult.Unknown;

            return PgnGameResult.Unknown;
        }
    }
}