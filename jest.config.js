module.exports = {
    collectCoverage: true,
    coverageThreshold: {
        global: {
            branches: 100,
            functions: 100,
            lines: 100,
            statements: 100,
        },
    },
    preset: 'ts-jest',
    testEnvironment: 'node',
    testMatch: ["<rootDir>/tests/**/*.test.ts"],
    modulePathIgnorePatterns: [
        "<rootDir>/build/"
    ]
};