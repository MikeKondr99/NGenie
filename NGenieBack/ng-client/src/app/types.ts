export interface MdDocument {
    id: string,
    title: string,
    text: string,
    owner: User,
}
export interface MdDocumentPatch {
    title: string,
    text: string,
}

export interface User {
    id: string,
    roles: UserRole[],
    firstName: string,
    lastName: string,
    avatar: string | null
}

export enum UserRole {
    student = 'student',
    teacher = 'teacher',
    admin = 'admin',
}