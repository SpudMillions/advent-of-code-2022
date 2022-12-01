export const createElfList = (calorieLog: number[]):number[] => {
    let elfList: number[] = [];
    let currentCalories: number = 0;
  
    calorieLog.forEach((logEntry: number) => {
      if(logEntry > 0) {
        currentCalories += logEntry;
      } else {
        elfList.push(currentCalories);
        currentCalories = 0;
      }
    });

    console.log(`elfList: ${elfList}`);
    return elfList;
}

export const maxCalorieEntry = (elfList: number[]):number => {
  return elfList.sort((a, b) => b - a).slice(0,1)[0];
};

export const caculateTopThreeElves = (elfList: number[]): number => {
  if(elfList.length > 3){
    const topThreeElves: number[] = elfList.sort((a, b) => a - b).slice(-3);
    return topThreeElves.reduce((a, b) => a + b);
  }
  return elfList.reduce((a, b) => a + b);
}