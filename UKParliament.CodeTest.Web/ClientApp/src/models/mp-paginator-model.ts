import { MPViewModel } from "./mp-view-model";

export interface MPPaginatorModel {
    data: MPViewModel[],
    currentPage: number,
    pageCount: number
}