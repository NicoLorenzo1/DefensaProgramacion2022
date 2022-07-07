using Telegram.Bot.Types;

namespace Library
{
    /// <summary>
    /// Clase CounterShotsHandler que se encarga de enviarle al usuario la cantidad de tiros que tocaron agua, los que tocaron barcos, y los disparos totales.
    /// Saca la información de game que es quien conoce la cantidad de shots.
    /// Para acceder a el debemos ejecutar el comando "disparos" o "Disparos" y nos mostrara la información que necesitamos.
    /// </summary>
    public class CounterShotsHandler : BaseHandler
    {
        private int resutlTotalSipShots = 0;
        private int result = 0;
        public CounterShotsState State { get; set; }
        public CounterShotsHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] { "Disparos", "disparos" };
            this.State = CounterShotsState.ShowShots;
        }
        protected override bool CanHandle(Message message)
        {
            return base.CanHandle(message);
        }

        protected override void InternalHandle(Message message, out string response)
        {
            response = string.Empty;
            if (State == CounterShotsState.ShowShots)
            {
                Game game = Administrator.Instance.GetPlayerGame(message.From.Id);

                resutlTotalSipShots = game.hitsPlayer1 + game.hitsPlayer2;

                result = game.watherShots + resutlTotalSipShots;

                if (game.player1.Id == message.From.Id)
                {
                    response = $"Los disparos que tocaron agua fueron: {game.watherShots}\n Los disparos que tocaron barco fueron: {resutlTotalSipShots} \n Los disparos totales fueron {result}";
                }
                else
                {
                    response = $"Los disparos que tocaron agua fueron: {game.watherShots}\n Los disparos que tocaron barco fueron: {resutlTotalSipShots} \n Los disparos totales fueron {result}";
                }
            }
        }
        public enum CounterShotsState
        {
            ShowShots,
        }

    }
}