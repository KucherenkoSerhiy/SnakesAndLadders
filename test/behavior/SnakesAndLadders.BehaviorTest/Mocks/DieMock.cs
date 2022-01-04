using SnakesAndLadders.Domain.SnakesAndLadders.Services;

namespace SnakesAndLadders.BehaviorTest.Mocks
{
    public class DieMock: IDie
    {
        public int ValueToThrow { private get; set; }

        public int Roll()
        {
            return ValueToThrow;
        }
    }
}