from subprocess import run

run(
    ["dotnet", "test", " --logger", "console;verbosity=detailed"],
    cwd="Testowanie.Tests",
)
