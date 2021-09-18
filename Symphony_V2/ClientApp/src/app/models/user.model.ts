export interface User {
    guid?: string;
    firstName: string;
    lastName: string;
    email: string;
    password: string;
    code: string;
    gender: number;
    dateOfBirth: Date;
}

export function displayGender(gender: number) {
    return gender === 0 ? 'Male' : 'Female'
}