export interface BroModel {
  id: string;
  nickname: string;
  email: string;
  avatarUrl: string | undefined;
}

export interface EventModel {
  id: string;
  title: string;
  location: string;
  start: string;
  organizer: BroModel;
  backgroundUrl: string | undefined;
}
