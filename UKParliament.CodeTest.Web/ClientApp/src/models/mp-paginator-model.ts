import { MPViewModel } from "./mp-view-model";

export interface MPPaginatorModel {
    data: MPViewModel[],
    totalItems: number,
    currentPage: number,
    pageCount: number
}