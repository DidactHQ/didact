export const useUser = () => {

  const username = ref<string>('John Doe');
  
  const refreshUsername = async (): Promise<void> => {
    username.value = await Promise.resolve('John Doe');
  }

  return {
    username,
    refreshUsername
  }
}