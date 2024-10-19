using Ucu.Poo.RoleplayGame;

namespace Library.Chars
{
    public interface IHero : ICharacter
    {
        int VictoryPoints { get; }
        void AddVictoryPoints(int vp);
    }
}