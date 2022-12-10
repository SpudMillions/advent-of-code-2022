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
Day5: Supply Stacks --- First Order Top Packages: FJSRQCFTN. Second Order Top Packages: CJVLJQPHS
Day6 : Tuning Trouble --- Characters Processed for 4 unique: 1566. Characters processed for 14 unique: 2265
Day7 : No Space Left On Device --- Total Size Available to Delete: 1307902. Directory to delete: jswfprpl with size 7068748
Day8 : Treetop Tree House --- There are 1715 trees visible. The best tree spot has 374400 trees visible.
Day9 : Rope Bridge --- Tail visited 6284 positions. Knots visited 2661 positions.
Day10 : Cathode-Ray Tube --- Signal Strength for X Register is 13820 jiggawatts. Rendering CRT Screen:

#### #  #  ##  ###  #  #  ##  ###  #  # 
   # # #  #  # #  # # #  #  # #  # # #  
  #  ##   #    #  # ##   #    #  # ##   
 #   # #  # ## ###  # #  # ## ###  # #  
#    # #  #  # # #  # #  #  # # #  # #  
#### #  #  ### #  # #  #  ### #  # #  # 
```

## New Problems
- Add `day{number}.txt` to `Inputs` folder
- Add `Day{number}.cs` to `Days` folder
- Inherit from `DayBase` and implement `Play` method
- Set `Day`, `Year` and `Title` with constructor