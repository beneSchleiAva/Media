import {Config} from "@jest/types";

const config: Config.InitialOptions = {
    preset: 'ts-jest',
    testEnvironment: 'node',
    moduleFileExtensions: ['ts', 'tsx', 'js', 'jsx', 'json', 'node'],
    transform: {
        '^.+\\.(ts|tsx)$': 'ts-jest',
     }, moduleNameMapper: {
            '^@/(.*)$': '<rootDir>/$1',
        },
        testMatch: ['<rootDir>/**/*.test.(ts|tsx|js|jsx)'],
        globals: {
            'ts-jest': {
                tsconfig: 'tsconfig.json',
            },
        }
};

export default config; 