import {maxCalorieEntry, createElfList, caculateTopThreeElves} from '../../src/Day1/calorie-counting';

describe('calorie counting', () => {
    it('should calculate top calories for 1 elf', () => {
        const calories = [1];
        const totalCalories = maxCalorieEntry(calories);
        expect(totalCalories).toBe(1);
    });

    it('should calculate top calories for 10 elves', () => {
        const calories = [1, 2, 3, 4, 5, 6, 7, 80, 9, 10];
        const totalCalories = maxCalorieEntry(calories);
        expect(totalCalories).toBe(80);
    });

    it('should create an elf list of total calories for 1 log entry', () => {
        const calories = [1,2,3,0];
        const elfList = createElfList(calories);
        expect(elfList.length).toBe(1);
    });

    it('should create an elf list of total calories for 2 log entries', () => {
        const calories = [1,2,3,0,4,5,6,0];
        const elfList = createElfList(calories);
        expect(elfList.length).toBe(2);
    });

    it('should calculate top 3+ elves', () => {
        const calories = [1,2,3,0,4,5,6,0,7,8,9,0,1,2,3,0];
        const elfList = createElfList(calories);
        const totalCalories = caculateTopThreeElves(elfList);
        expect(totalCalories).toBe(45);
    });

    it('should calculate top 3 elves, when there are only 2 elves', () => {
        const calories = [1,2,3,0,4,5,6,0];
        const elfList = createElfList(calories);
        const totalCalories = caculateTopThreeElves(elfList);
        expect(totalCalories).toBe(21);
    });

})