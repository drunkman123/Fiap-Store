export function httpService() {
  const createRequest = async (path: string, method: string, data: any = null) => {
    let token = localStorage.getItem('token');
    let response = await fetch(`http://localhost:5000/${path}`, {
      method: method,
      body: data ? JSON.stringify(data) : null,
      headers: {
        'Content-Type': 'application/json',
        'Authorization': `Bearer ${token}`,
      }
    });

    return response;
  }

  return {
    get: async (path: string) => await createRequest(path, 'GET'),
    post: async (path: string, data: any) => await createRequest(path, 'POST', data),
  }
}