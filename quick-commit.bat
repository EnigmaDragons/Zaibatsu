@echo off
set arg1=%1
git checkout src/Zaibatsu/ProjectSettings/QualitySettings.asset
git add .
git commit -m %arg1%
git pull
git push
