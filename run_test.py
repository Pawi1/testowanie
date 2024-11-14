from subprocess import run
from os import path

if not path.isdir("./Testowanie.Tests/bin"):
    if path.exists("build.py"):
        run(["python", "build.py"])
    else:
        run(["dotnet", "build"], cwd="Testowanie")
        run(["dotnet", "build"], cwd="Testowanie.Tests")
run(
    ["dotnet", "test", "--logger", "console;verbosity=detailed"], cwd="Testowanie.Tests"
)

