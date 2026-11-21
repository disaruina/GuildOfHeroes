// Probe.Run();

Guild guild = new Guild("Гильдия героев");

Hero sergey = new Hero("Сергей", 110);
Hero yaroslav = new Hero("Ярослав", 100);
Hero elena = new Hero("Елена", 95);
Hero artem = new Hero("Артём", 90);
Hero nina = new Hero("Нина", 85);

guild.AddHero(sergey);
guild.AddHero(yaroslav);
guild.AddHero(elena);
guild.AddHero(artem);
guild.AddHero(nina);

Console.WriteLine($">>> {guild.Name}: участников {guild.GetMembers().Count} <<<");
Console.WriteLine();

QuestBoard board = new QuestBoard(guild);

board.AddQuest(new Quest(101, "Вернуть поплавок", 100, 30));
board.TryAssign(101, "Сергей");
board.TryComplete(101);

board.AddQuest(new Quest(102, "Проверить нижнюю площадку", 100, 10));
board.AddQuest(new Quest(103, "Снять мерки для насоса больницы", 100, 20));
board.AddQuest(new Quest(104, "Обследовать ответвление", 100, 15));

Console.WriteLine($"Сергей на №102: {board.TryAssign(102, "Сергей")}");
Console.WriteLine($"Сергей на №103: {board.TryAssign(103, "Сергей")}");
Console.WriteLine($"Отмена №102: {board.TryCancel(102)}");
Console.WriteLine($"Сергей на №103: {board.TryAssign(103, "Сергей")}");
Console.WriteLine($"Завершение №103: {board.TryComplete(103)}");
Console.WriteLine($"Ярослав на №104: {board.TryAssign(104, "Ярослав")}");
Console.WriteLine($"Удалить Сергея: {board.TryRemoveMember("Сергей")}");

Console.WriteLine();
List<Quest> quests = board.GetQuests();
foreach (Quest quest in quests) {
    Console.WriteLine(quest.GetInfo());
}

Console.WriteLine($"Открыто: {board.CountByStatus(QuestStatus.Open)}, " +
                  $"назначено: {board.CountByStatus(QuestStatus.Assigned)}, " +
                  $"выполнено: {board.CountByStatus(QuestStatus.Completed)}, " +
                  $"отменено: {board.CountByStatus(QuestStatus.Cancelled)}");

Quest? yaroslavQuest = board.FindActiveQuest("Ярослав");
if (yaroslavQuest != null) {
    Console.WriteLine($"Ярослав сейчас: №{yaroslavQuest.Id} «{yaroslavQuest.Title}»");
}

Quest? sergeyQuest = board.FindActiveQuest("Сергей");
if (sergeyQuest == null) {
    Console.WriteLine("Сергей сейчас: свободен");
}

Console.WriteLine();
Console.WriteLine(sergey.GetInfo());

