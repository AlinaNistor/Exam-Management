import { UserModel } from './user.model';

export type CommentModel = {
  id: string;
  parentId: string;
  userId: string;
  examId: string;
  text: string;
  dateAdded: string;
  user?: UserModel;
};

export * from './comment.model';
