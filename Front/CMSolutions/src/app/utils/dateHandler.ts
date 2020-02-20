import * as moment from 'moment';

export const showDate = (date: string): string => moment(date).format('DD/MM/YYYY');
export const dateToService = (date: string): string => moment(date).format('DD/MM/YYYY') + 'T00:00:00';
