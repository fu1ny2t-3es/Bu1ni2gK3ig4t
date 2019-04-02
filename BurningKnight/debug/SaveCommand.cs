using System.Threading;
using BurningKnight.save;
using Lens;

namespace BurningKnight.debug {
	public class SaveCommand : ConsoleCommand {
		public SaveCommand() {
			Name = "save";
			ShortName = "s";
		}
		
		public override void Run(Console console, string[] args) {
			if (args.Length != 1 && args.Length != 2) {
				console.Print("save [save path] (save type)");
				return;
			}

			var path = args[0];
			var saveType = args.Length == 1 ? "all" : args[1];
			var area = Engine.Instance.State.Area;
			
			var thread = new Thread(() => {
				switch (saveType) {
					case "all": {
						SaveManager.Save(area, SaveType.Level, false, path);
						SaveManager.Save(area, SaveType.Player, false, path);
						SaveManager.Save(area, SaveType.Game, false, path);
						SaveManager.Save(area, SaveType.Global, false, path);
						break;
					}

					case "level": {
						SaveManager.Save(area, SaveType.Level, false, path);
						break;
					}

					case "player": {
						SaveManager.Save(area, SaveType.Player, false, path);
						break;
					}

					case "game": {
						SaveManager.Save(area, SaveType.Game, false, path);
						break;
					}

					case "global": {
						SaveManager.Save(area, SaveType.Global, false, path);
						break;
					}

					case "run": {
						SaveManager.Save(area, SaveType.Level, false, path);
						SaveManager.Save(area, SaveType.Player, false, path);
						SaveManager.Save(area, SaveType.Game, false, path);
						break;
					}

					default: {
						console.Print($"Unknown save type ${saveType}. Should be one of all, level, player, game, global, run");
						break;
					}
				}
					
				console.Print($"Done saving {saveType}");
			});
			
			thread.Start();
		}
	}
}