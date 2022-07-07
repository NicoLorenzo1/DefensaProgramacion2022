using Telegram.Bot.Types;

namespace Library
{
    /// <summary>
    /// Clase CounterShotsHandler que se encarga de enviarle al usuario la cantidad de tiros que tocaron agua, los que tocaron barcos, y los totales.
    /// Saca la información de game que es quien conoce la cantidad de shots.
    /// </summary>
    public class CounterShotsHandler : BaseHandler
    {
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

                int resutlTotalSipShots = game.hitsPlayer1 + game.hitsPlayer2;

                int result = game.watherShots + resutlTotalSipShots;

                if (game.player1.Id == message.From.Id)
                {
                    Bot.sendTelegramMessage(game.player1, $"Los disparos que tocaron agua fueron: {game.watherShots}\n Los disparos que tocaron barco fueron: {resutlTotalSipShots} \n Los disparos totales fueron {result}");
                }
                else
                {
                    Bot.sendTelegramMessage(game.player2, $"Los disparos que tocaron agua fueron: {game.watherShots}\n Los disparos que tocaron barco fueron: {resutlTotalSipShots} \n Los disparos totales fueron {result}");
                }

            }
        }
        public enum CounterShotsState
        {
            ShowShots,
        }

    }
}