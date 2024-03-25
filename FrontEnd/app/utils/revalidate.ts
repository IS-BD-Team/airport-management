"use server";

import { revalidateTag, revalidatePath } from 'next/cache';

export const revalidateServerPath = async (path: string) => {
    revalidatePath(path);
};

export const revalidateServerTag = async (tag: string) => {
    revalidateTag(tag);
}
