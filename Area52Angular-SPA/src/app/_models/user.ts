import { Book } from './book';

export interface User {
    id: number;
    username: string;
    nickname: string;
    books?: Book[];
}
