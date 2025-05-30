'use client';

import { useState, useEffect } from 'react';
import { ProgressPhotoDto } from '../../lib/types';
import apiClient from '../../lib/api/client';
import { useAuth } from '../../../context/AuthContext';
// import ProgressPhotoCard from '../../components/forms/ProgressPhotoCard';
// import ProgressPhotoModal from '../../components/forms/ProgressPhotoModal';

export default function ProgressPage() {
  const [photos, setPhotos] = useState<ProgressPhotoDto[]>([]);
  const [loading, setLoading] = useState(true);
  const [isModalOpen, setIsModalOpen] = useState(false);
  const { user } = useAuth();

  useEffect(() => {
    const fetchProgressPhotos = async () => {
      try {
        const response = await apiClient.get(`/progress/user/${user?.id}`);
        setPhotos(response.data);
      } catch (error) {
        console.error('Failed to fetch progress photos', error);
      } finally {
        setLoading(false);
      }
    };

    if (user?.id) {
      fetchProgressPhotos();
    }
  }, [user?.id]);

  const handleAddPhoto = async (photoData: ProgressPhotoDto) => {
    try {
      const response = await apiClient.post('/progress', {
        ...photoData,
        userId: user?.id,
      });
      setPhotos([...photos, response.data]);
      setIsModalOpen(false);
    } catch (error) {
      console.error('Failed to add progress photo', error);
    }
  };

  if (loading) {
    return <div>Loading...</div>;
  }

  return (
    <div className="space-y-6">
      <div className="flex justify-between items-center">
        <h1 className="text-2xl font-bold">Progress Photos</h1>
        <button
          onClick={() => setIsModalOpen(true)}
          className="px-4 py-2 bg-indigo-600 text-white rounded-md hover:bg-indigo-700"
        >
          Add Photo
        </button>
      </div>

      {/* {photos.length === 0 ? (
        <div className="text-center py-12">
          <p className="text-gray-500">No progress photos yet. Add your first photo!</p>
        </div>
      ) : (
        <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-6">
          {photos.map((photo) => (
            <ProgressPhotoCard key={photo.id} photo={photo} />
          ))}
        </div>
      )}

      <ProgressPhotoModal
        isOpen={isModalOpen}
        onClose={() => setIsModalOpen(false)}
        onSubmit={handleAddPhoto}
      /> */}
    </div>
  );
}