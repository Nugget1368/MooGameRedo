namespace MooGame.UI
{
    public interface IUI<T>
    {
        string EnterName();
        bool GameOver(T data);
        void HighScore(List<T> data);
        string PlayerInput();
        bool Result(string checkResult);
    }
}