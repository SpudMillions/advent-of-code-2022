# Advent of Code
This repository contains my solutions for [advent of code.](https://adventofcode.com)

## How to use
`dotnet run`

[Configure VSCode if needed](https://code.visualstudio.com/docs/languages/dotnet#_setting-up-vs-code-for-net-development)

## Output
```
Day1: Calorie Counting -- Max calorie entry: 70764, Top three elves: 203905
Day2: Total score: 15523, Total score part two: 15702
Day3: Rucksack Reorganization -- Total score: 7691, Total score part two: 2508
Day4: Camp Cleanup -- Total overlapping completely: 560, Total any overlap: 839
```

## New Problems
- Add `day{number}.txt` to `Inputs` folder
- Add `Day{number}.cs` to `Days` folder
- Inherit from `DayBase` and implement `Play` method
- Set `Day`, `Year` and `Title` with constructor