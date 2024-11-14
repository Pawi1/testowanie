from subprocess import run
from os import path

if not path.isdir("./Testowanie.Tests/bin"):
   if path.exist("build.py") 
       run(["python", "build.py"])
run(
    ["dotnet", "test", "--logger", "console;verbosity=detailed"],
    cwd="Testowanie.Tests"
)