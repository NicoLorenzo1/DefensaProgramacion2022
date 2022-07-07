using Telegram.Bot.Types;

namespace Library
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "tablero".
    /// </summary>
    public class CounterShotsHandler : BaseHandler
    {

        /// <summary>
        /// Esta clase procesa el mensaje "tablero".
        /// </summary>
        /// <param name="next">El próximo "handler".</param>
        public CounterShotsHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] { "Disparos" };
        }
        protected override bool CanHandle(Message message)
        {
            return base.CanHandle(message);
        }

        /// <summary>
        ///Test que se encarga de testear la nueva funcionalidad añadida a travéz del handler CounterShot
        /// <summary>
        protected override void InternalHandle(Message message, out string response)
        {
            response = "No hay un juego en curso";

            User from, to;
            int water, ship, total;
            Game game = Administrator.Instance.GetPlayerGame(message.From.Id);
            if (game != null)
            {
                if (game.player1.Id == message.From.Id)
                {
                    from = game.player1;
                    to = game.player2;
                }
                else
                {
                    from = game.player2;
                    to = game.player1;
                }
                ship = game.hitsPlayer1 + game.hitsPlayer2;
                total = game.boardPlayer1.shots.Count + game.boardPlayer1.shots.Count;
                water = total = ship;

                string msj = $"Los disparos fueron: {water} al agua, {ship} a barcos. Total {total} ";
                response = string.Empty;
                Bot.sendTelegramMessage(from, msj);
            }
        }
    }
}