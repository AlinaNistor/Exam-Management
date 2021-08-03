export type CommentModel = {
  id: string;
  parentId: string;
  userId: string;
  examId: string;
  text: string;
  dateAdded: string;
};

export * from './comment.model';
